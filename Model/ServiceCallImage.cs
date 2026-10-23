using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ServiceCallImage : BaseEntity
    {
        public int CallID { get; set; }
        public string ImagePath { get; set; }

        public ServiceCallImage(int callID, string imagePath)
        {
            CallID = callID;
            ImagePath = imagePath;
        }

        public ServiceCallImage(int id, int callID, string imagePath)
        {
            Id = id;
            CallID = callID;
            ImagePath = imagePath;
        }

        public int ID
        {
            get => Id;
            set => Id = value;
        }

        public ServiceCallImage()
        {
        }
    }
}