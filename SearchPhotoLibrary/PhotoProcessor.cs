using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SearchPhotoLibrary
{
    /// <summary>
    /// Class that contains method for getting specific photos by passing query or generating random photos
    /// </summary>
    public class PhotoProcessor
    {
        /// <summary>
        /// Methods that uses google api to get url of photos
        /// </summary>
        /// <param name="query">it's a specific text used to search photo provided by user</param>
        /// <returns>List of photos uri</returns>
        public static async Task<PhotoModel> LoadPhoto(string query)
        {
            string queryTerm = query;
            int imageAmount = 10;
            string key = "&key=AIzaSyD1ZKe3T1AO71vYlI4reK4-q3dTKfVtxuQ"; 
            string cx = "&cx=012312041580636005008:2httsyobkoe"; 
            
            if(queryTerm == "")
            {
                queryTerm = " ";
            }

            string url = "https://www.googleapis.com/customsearch/v1?q=" + queryTerm + cx + "&imgSize=medium&num=" + imageAmount + "&searchType=image" + key;
            // string url = "https://www.googleapis.com/customsearch/v1?q=cat&cx=012312041580636005008%3A2httsyobkoe&imgSize=medium&num=8&searchType=image&key=AIzaSyD1ZKe3T1AO71vYlI4reK4-q3dTKfVtxuQ";

            var json = new WebClient().DownloadString(url);
            dynamic data = JObject.Parse(json);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {   
                    PhotoModel photo = new PhotoModel();
                    for (int i =0; i < imageAmount; i++)
                    {  
                        photo.uriList.Add(new Uri(Convert.ToString(data.items[i].link), UriKind.Absolute));  
                    }
                    return  photo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        /// <summary>
        /// Method that generate Random Photos
        /// </summary>
        /// <returns>List of random generated photos uri</returns>

        public static async Task<PhotoModel> RandomPhoto()
        {

            int imageAmount = 1;
            string key = "&key=AIzaSyD1ZKe3T1AO71vYlI4reK4-q3dTKfVtxuQ";
            string cx = "&cx=012312041580636005008:2httsyobkoe";
            string[] wordsDictionary = new string[] { "Cat", "Car", "Hammer", "Truck", "Tree", "Bush", "Flower", "Chair", "Desk", "Shoes", "Hat",
            "Socks", "Tire", "Snow", "Mud", "Rain", "Sun", "Water", "Desert", "Stone", "Mercedes", "Ford", "Mustang", "BMW"};

            List<string> queryRandomWords = new List<string>();
            for(int i = 0; i < wordsDictionary.Length - 1; i++)
            {
                queryRandomWords.Add(wordsDictionary[i]);
            }


            List<string> urls = new List<string>();
            string url= "";

            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                int randomValue = rnd.Next(0, wordsDictionary.Length - 1);
                url = "https://www.googleapis.com/customsearch/v1?q=" + queryRandomWords[randomValue] + cx + "&imgSize=medium&num=" + imageAmount + "&searchType=image" + key;
                queryRandomWords.RemoveAt(randomValue);
                urls.Add(url);
            }



            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PhotoModel photo = new PhotoModel();
                    for (int i = 0; i < 5; i++)
                    {
                        var json = new WebClient().DownloadString(urls[i]);
                        dynamic data = JObject.Parse(json);
                       
                        photo.uriList.Add(new Uri(Convert.ToString(data.items[0].link), UriKind.Absolute));     
                    }
                    return photo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
