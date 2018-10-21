using Latelier.Facemash.Dal.Dao;
using Latelier.Facemash.Front.Models;
using System.Collections.Generic;

namespace Latelier.Facemash.Front.Helper
{
    /// <summary>
    /// Application assembker
    /// </summary>
    public static class Assemebler
    {
        /// <summary>
        /// Transform to cats
        /// </summary>
        /// <param name="images">Json image</param>
        /// <returns>List of cats</returns>
        public static List<Cat> ToCats(this List<Image> images)
        {
            if (images == null)
                return null;

            List<Cat> list = new List<Cat>();

            foreach (var image in images)
            {
                list.Add(new Cat
                {
                    Id = image.id,
                    Url = image.url,
                    Score = 0
                });
            }

            return list;
        }
    }
}