using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAteneav2.Logic
{
    public class FacebookPosts
    {
        public void algo()
        {
            var client = new FacebookClient("CAAOPIFhMpWUBAImanX9cRByLuMkEbD0yXUpdHXG2EDIH8KYhDPzzZCPvEoy0kZBKw5NZAWoq0ysVSXZCNIM5Beyj73DsiAcAR8NcEJvJjyZAXkUUx88WeU4ZCT6ZCa3VxRqXokP258en8OqCJT34BAfLgBTAz0dMQ3ZAGwDye2Un5IGnZAZBWhvjGN2WCNBZCcT2O5YjrLUvvGNmAZDZD");
            dynamic result = client.Get("/me/posts");

            //all the posts and their information is strored in result.data not in result

            for (int i = 0; i < result.data.Count; i++)
            {
                if (!object.ReferenceEquals(result.data[i].message, null))
                {
                    //tb.Text += result.data[i].message + "\n";
                }
            }
        }

    }
}