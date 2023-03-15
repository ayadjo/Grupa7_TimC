using InitialProject.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Image : ISerializable
    {
        public int Id { get; set; }
        public String Url { get; set; }
        public int ResourceId { get; set; }//prvo smestaj/tura pa slika
        //type
        public String Description { get; set; }
        public Image() { }
        public Image(String url, int resourceId, String description)
        {
            Url = url;
            ResourceId = resourceId;
            Description = description;
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Url, ResourceId.ToString(), Description };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            Url = values[1];
            ResourceId = Convert.ToInt32(values[2]);
            Description = values[3];
        }
    }
}
