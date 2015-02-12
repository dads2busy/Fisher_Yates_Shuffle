using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString FY_Shuffle(string seed, string characters)
    {
        char[] shuffleArray = characters.ToCharArray();

        Guid guid = new Guid(seed);
        byte[] gu = guid.ToByteArray();
        int seedInt = BitConverter.ToInt32(gu, 0);

        Random random = new Random(seedInt);

        for (int i = shuffleArray.Length; i > 1; i--)
        {
            // Pick random element to swap.
            int j = random.Next(i); // 0 <= j <= i-1
            // Swap.
            char tmp = shuffleArray[j];
            shuffleArray[j] = shuffleArray[i - 1];
            shuffleArray[i - 1] = tmp;
        }

        StringBuilder builder = new StringBuilder();
        foreach (char value in shuffleArray)
        {
            builder.Append(value);
        }
        return builder.ToString();
    }

}

