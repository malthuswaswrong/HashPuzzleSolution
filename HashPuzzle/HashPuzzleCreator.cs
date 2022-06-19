using System.Security.Cryptography;
using System.Text;

namespace HashPuzzle;

public class HashPuzzleCreator
{
    private SHA256 hasher;
    Random rand = new Random();    
    public HashPuzzleCreator()
    {
        hasher = SHA256.Create();
    }

    public string FindSolution(byte[] target)
    {
        while(true)
        {
            string rnd = GenerateRandomString(64);
            byte[] test = hasher.ComputeHash(Encoding.UTF8.GetBytes(rnd));
            if(Overlaps(test, target))
            {
                return rnd;
            }
        }
    }


    private bool Overlaps(byte[] full, byte[] partial)
    {
        foreach(byte b in partial)
        {
            if(!full.Contains(b)) return false;
        }
        return true;
    }

    public byte[] GetTarget(int size)
    {
        byte[] result = new byte[size];
        for (int i = 0; i < size; i++)
        {
            result[i] = (byte)rand.Next(0, 255);
        }
        return result;
    }
    public string GenerateRandomString(int len)
    {
        int v;
        string result = "";
        char c;
        for (int j = 0; j < len; j++)
        {
            v = rand.Next(0, 26);
            c = Convert.ToChar(v + 65);
            result = $"{result}{c}";
        }
        return result;
    }
}