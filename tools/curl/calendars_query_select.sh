#!/bin/sh

curl --location --request GET 'https://localhost:5001/calendars/query?$select=Owner,Type'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
#       SELECT `c`.`Owner`, `c`.`Type`, `c`.`Id`
#       FROM `Calendars` AS `c`
