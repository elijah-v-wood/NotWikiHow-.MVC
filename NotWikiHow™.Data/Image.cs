using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotWikiHow_.Data
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
