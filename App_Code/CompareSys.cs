using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 *@Date - 29 March 2012
 *@Autor - Borislav Borisov
 *@Institution - University of Dundee
 *@Purpose - Yahoo, Hack U Day - 30 March 2012
 *@Description - Data compare.
 */
public class CompareSys
{
    int MaxTemp = 0;
    int MinTemp = 0;
    int MaxCycle = 0;
    int MinCycle = 0;

	public CompareSys()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool HDDDataCompare(int temp, int cycle)
    {
        MaxTemp = 55;
        MinTemp = 14;
        MaxCycle = 370000;
        MinCycle = 1;
        if (temp > MaxTemp || temp < MinTemp)
        {
            if (temp == 0)
            {
                return false;
            }

            return true;
        }
        else if (cycle > MaxCycle || cycle < MinCycle)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}