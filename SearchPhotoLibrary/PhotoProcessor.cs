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
    public class PhotoProcessor
    {
        public static async Task<PhotoModel> LoadPhoto(string query)
        {
            string queryTerm = query;
            int imageAmount = 10;
            string key = "&key=AIzaSyD1ZKe3T1AO71vYlI4reK4-q3dTKfVtxuQ"; 
            string cx = "&cx=012312041580636005008:2httsyobkoe"; 
            

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
    }
}
