using System;

namespace Day01
{
    class Program
    {
        static void Part1(int[] input, int targetSum)
        {
            Array.Sort(input);

            int l = 0;
            int r = input.Length - 1;

            // O(nlogn) time complexity
            // O(nlogn) because of the sort, otherwise O(n)
            while (l < r)
            {
                if ((input[l] + input[r]) < targetSum) l++;
                else if ((input[l] + input[r]) > targetSum) r--;
                else if ((input[l] + input[r]) == targetSum) break;
            }

            int left = input[l];
            int right = input[r];
            int product = left * right;
            Console.WriteLine($"Numbers are: {left}, {right}. Product is: {product}");
        }

        static void Part2(int[] input, int targetSum)
        {
            Array.Sort(input);

            int l = 0;
            int m = l + 1;
            int r = input.Length - 1;
            bool found = false;

            for(l = 0; l < m; l++)
            {
                m = l + 1;
                r = input.Length - 1;

                while (!found && m < r)
                {
                    if ((input[l] + input[m] + input[r]) < targetSum) m++;
                    else if ((input[l] + input[m] + input[r]) > targetSum) r--;
                    else if ((input[l] + input[m] + input[r]) == targetSum) found = true;
                }

                if (found) break;
            }

            int left = input[l];
            int middle = input[m];
            int right = input[r];
            int product = left * middle * right;
            Console.WriteLine($"Numbers are: {left}, {middle}, {right}. Product is: {product}");
        }

        static void Main(string[] args)
        {
            int targetSum = 2020;
            var input = new int[] {1914,1931,1892,1584,1546,1988,1494,1709,1624,1755,1849,1430,1890,1675,1604,1580,1500,1277,1729,1456,2002,1075,1512,895,1843,1921,1904,1989,1407,1552,1714,757,1733,1459,1777,1440,1649,1409,1662,1968,1775,1998,1754,1938,1964,1415,1990,1997,1870,1664,1145,1782,1820,1625,1599,1530,1759,1575,1614,1869,1620,1818,1295,1667,1361,1520,1555,1485,1502,1983,1104,1973,1433,1906,1583,1562,1493,1945,1528,1600,1814,1712,1848,1454,1801,1710,1824,1426,1977,1511,1644,1302,1428,1513,1261,1761,1680,1731,1724,1970,907,600,1613,1091,1571,1418,1806,1542,1909,1445,1344,1937,1450,1865,1561,1962,1637,1803,1889,365,1810,1791,1591,1532,1863,1658,1808,1816,1837,1764,1443,1805,1616,1403,1656,1661,1734,1930,1120,1920,1227,1618,1640,1586,1982,1534,1278,1269,1572,1654,1472,1974,1748,1425,1553,1708,1394,1417,1746,1745,1834,1787,1298,1786,1966,1768,1932,1523,1356,1547,1634,1951,1922,222,1461,1628,1888,1639,473,1568,1783,572,1522,1934,1629,1283,1550,1859,2007,1996,1822,996,1911,1689,1537,1793,1762,1677,1266,1715};
            Part1(input, targetSum);
            Part2(input, targetSum);
        }
    }
}
