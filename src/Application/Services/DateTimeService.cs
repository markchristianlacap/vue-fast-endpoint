﻿using Database.Interfaces;

namespace Application.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
}
