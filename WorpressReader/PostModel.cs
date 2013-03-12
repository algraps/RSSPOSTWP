/*
 * Post Model
 * Author: Alessandro Graps
 * Year: 2013
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorpressReader
{
    [Serializable]
    public class PostModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
