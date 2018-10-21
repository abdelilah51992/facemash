FaceMash = new function () {
    this.SaveInStorage = function (cats) {
        localStorage.setItem('cats', JSON.stringify(cats));
    };
    this.GetInStorage = function () {
        var retrievedObject = localStorage.getItem('cats');
        return JSON.parse(retrievedObject);
    };
    this.LoadAll = function () {
        $.ajax({
            url: "/api/cat/all"
        }).done(function (data) {
            FaceMash.SaveInStorage(data);

            if ($("#catsList").length === 0)
                return;
            $.each(data, function (i, cat) {
                $("#catsList").append(
                    '<div class="col-sm-6 col-md-4">' +
                    '<div class="thumbnail">' +
                    '<img class="cat-image" src="' + cat.url + '" alt="...">' +
                    '<div class="caption">' +
                    '<h3>' + cat.id + '</h3>' +
                    '<p>score  : ' + cat.score + '</p>' +
                    '</div>' +
                    '</div>' +
                    '</div>'
                );
            });
        });
    };
    this.LoadPair = function () {
        var cats = FaceMash.GetInStorage();

        if (cats === null || cats.length === 0) {
            FaceMash.LoadAll();
            FaceMash.FaceMash();
            return;
        }
        var leftIndex = this.getRandomIn(0, cats.length);
        var rightIndex = this.getRandomIn(0, cats.length);

        var left = cats[leftIndex];
        var right = cats[rightIndex];
        FaceMash.load('#Catleft', left);
        FaceMash.load('#CatRight', right);
    };
    this.load = function (htmlId, cat) {
        if (cat == undefined || cat == null)
            return;

        $(htmlId).attr("data-id", cat.id);
        $(htmlId).html(
            '<img src="' + cat.url + '" alt="' + cat.id + '" class="img-circle">' +
            '<h3>' + cat.id + '</h3>'
        );
    };
    this.Vote = function (htmlid) {
        var id = $(htmlid).attr("data-id");
        $.ajax({
            url: "/api/cat/vote/" + id,
            method: "POST"
        }).done(function (data) {
            FaceMash.LoadPair();
        });
    };

    this.getRandomIn = function (min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    };
};

$.ajax({
    beforeSend: function () {
        $(".ajax-busy-indicator").show();
    },
    complete: function () {
        $(".ajax-busy-indicator").hide();
    }
});