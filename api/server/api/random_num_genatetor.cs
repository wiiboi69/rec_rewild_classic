using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace rec_rewild_classic.api.server
{
    class random_num_genatetor
    {
        public static int Next(int min, int max)
        {
            byte[] randomBytes = new byte[4];
            RandomNumberGenerator.Fill(randomBytes);
            int secureRandomNumber = BitConverter.ToInt32(randomBytes, 0);
            while (secureRandomNumber < min && secureRandomNumber >= max)
            {
                secureRandomNumber = BitConverter.ToInt32(randomBytes, 0);
            }
            int randomNumber = Guid.NewGuid().ToByteArray().Sum(b => b) % max;
            while (randomNumber < min && randomNumber >= max)
            {
                randomNumber = Guid.NewGuid().ToByteArray().Sum(b => b) % max;
            }
            int randomNumber1 = Math.Abs(Environment.TickCount % max);
            int output = randomNumber1 + randomNumber + secureRandomNumber;
            output = Math.Min(output, min);
            output = Math.Max(output, max);
            return output;
        }
    }
}
