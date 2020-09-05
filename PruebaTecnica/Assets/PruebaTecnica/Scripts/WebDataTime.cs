using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WebDataTime
{
    public string abbreviation { get; set; }
    public string client_ip { get; set; }
    public DateTime datetime { get; set; }
    public int day_of_week { get; set; }
    public int day_of_year { get; set; }
    public bool dst { get; set; }
    public DateTime dst_from { get; set; }
    public int dst_offset { get; set; }
    public DateTime dst_until { get; set; }
    public int raw_offset { get; set; }
    public string timezone { get; set; }
    public int unixtime { get; set; }
    public DateTime utc_datetime { get; set; }
    public string utc_offset { get; set; }
    public int week_number { get; set; }

    public WebDataTime()
    {
        abbreviation = "";
        client_ip = "";
        datetime = new DateTime();
        day_of_year = 0;
        day_of_week = 0;
        dst = false;
        dst_from = new DateTime();
        dst_offset = 0;
        dst_until = new DateTime();
        raw_offset = 0;
        timezone = "";
        unixtime = 0;
        utc_datetime = new DateTime();
        utc_offset = "";
        week_number = 0;
    }
    public WebDataTime(WebDataTime p_copy)
    {
        abbreviation = p_copy.abbreviation;
        client_ip = p_copy.client_ip; ;
        datetime = p_copy.datetime ;
        day_of_year = p_copy.day_of_year; ;
        day_of_week = p_copy.day_of_week; ;
        dst = p_copy.dst; ;
        dst_from = p_copy.dst_from; ;
        dst_offset = p_copy.dst_offset; ;
        dst_until = p_copy.dst_until; ;
        raw_offset = p_copy.raw_offset; ;
        timezone = p_copy.timezone; ;
        unixtime = p_copy.unixtime; ;
        utc_datetime = p_copy.utc_datetime; ;
        utc_offset = p_copy.utc_offset; ;
        week_number = p_copy.week_number; ;
    }
}

