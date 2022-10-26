int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

IEnumerable<int> numPares = from num in numeros where num%2==0 select num;

foreach(int num in numPares)
{
    Console.Write("{0, 1} ", num);
}
