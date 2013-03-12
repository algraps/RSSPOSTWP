/*
 * Manager
 * Author: Alessandro Graps
 * Year: 2013
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WorpressReader
{
    public static class PostManager
    {
        public static IList<PostModel> GetBlogPosts(string postUrl, int postCount)
	    {
            try
            {

                string xml;

                using (WebClient downloader = new WebClient())
                {
                    using (TextReader reader =
                        new StreamReader(downloader.OpenRead(postUrl)))
                    {
                        xml = reader.ReadToEnd();
                    }
                }

                // Sanitize the XML

                xml = XmlCommon.SanitizeXmlString(xml);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                XNamespace dc= "http://purl.org/dc/elements/1.1/";
	
                //Load feed via a feedUrl.
                TextReader tr = new StringReader(xml);
                var doc = XDocument.Load(tr);

                //Get all the "items" in the feed.
                var feeds = doc.Descendants("item").Select(x =>
                        new PostModel
                        {
                            //Get title, pubished date, and link elements.
                            Title = x.Element("title").Value, //3
                            Author = x.Element(dc + "creator").Value,
                            PublishedDate = DateTime.Parse(x.Element("pubDate").Value),
                            Url = x.Element("link").Value
                        } //  Put them into an object (Post)
                        )
                    // Order them by the pubDate (Post.PublishedDate).
                        .OrderByDescending(x => x.PublishedDate)
                    //Only get the amount specified, the top (1, 2, 3, etc.) via postCount.
                        .Take(postCount);

                //Convert the feeds to a List and return them.
                return feeds.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
		    
	    }      
    }
}
