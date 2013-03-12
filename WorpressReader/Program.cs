/*
 * Get Posts from wordpress blog
 * Author: Alessandro Graps
 * Year: 2013
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorpressReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://nothingnessit.wordpress.com/feed/";

            Console.WriteLine("Get Posts from wordpress blog");
            Console.WriteLine("Author: Alessandro Graps");
            Console.WriteLine("Year: 2013");
            Console.WriteLine(url);
            Console.WriteLine();
            Console.WriteLine("Posts:");
            IList<PostModel> lista =  PostManager.GetBlogPosts(url, 10);
            foreach (var postModel in lista)
            {
                Console.WriteLine(string.Format("{0} - {1}", postModel.Title, postModel.Author));
            }
            Console.ReadLine();

        }
    }
}
