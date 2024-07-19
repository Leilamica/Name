using System;
using System.Collections.Generic;
using Name.model;
using Name.Data;

namespace Name.business;

public class InfoServices
{
    private InfoData _infoData;

    public InfoServices()
    {
        _infoData = new InfoData();
    }

    public bool AddInfo(Info info)
    {
        try
        {
            int rowsAffected = _infoData.AddInfo(info);
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding info: {ex.Message}");
            return false;
        }
    }

    public bool UpdateInfo(Info info)
    {
        try
        {
            int rowsAffected = _infoData.UpdateInfo(info);
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating info: {ex.Message}");
            return false;
        }
    }

    public bool DeleteInfo(string infoName)
    {
        try
        {
            int rowsAffected = _infoData.DeleteInfo(infoName);
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting info: {ex.Message}");
            return false;
        }
    }

    public List<Info> GetAllInfos()
    {
        try
        {
            return _infoData.GetInfos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving infos: {ex.Message}");
            return new List<Info>();
        }
    }
}
