using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrintHistory
{
    public class Row
    {
        public string Date;
        public string Time;
        public string User;
        public string Pages;
        public string Title;

    }

    List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.Date = grid[i][0];
            row.Time = grid[i][1];
            row.User = grid[i][2];
            row.Pages = grid[i][3];
            row.Title = grid[i][4];

            rowList.Add(row);
        }
        isLoaded = true;
    }

    public int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public Row Find_Date(string find)
    {
        return rowList.Find(x => x.Date == find);
    }
    public List<Row> FindAll_Date(string find)
    {
        return rowList.FindAll(x => x.Date == find);
    }
    public Row Find_Time(string find)
    {
        return rowList.Find(x => x.Time == find);
    }
    public List<Row> FindAll_Time(string find)
    {
        return rowList.FindAll(x => x.Time == find);
    }
    public Row Find_User(string find)
    {
        return rowList.Find(x => x.User == find);
    }
    public List<Row> FindAll_User(string find)
    {
        return rowList.FindAll(x => x.User == find);
    }
    public Row Find_Pages(string find)
    {
        return rowList.Find(x => x.Pages == find);
    }
    public List<Row> FindAll_Pages(string find)
    {
        return rowList.FindAll(x => x.Pages == find);
    }
    public Row Find_Title(string find)
    {
        return rowList.Find(x => x.Title == find);
    }
    public List<Row> FindAll_Title(string find)
    {
        return rowList.FindAll(x => x.Title == find);
    }

}