#!/bin/sh

curl --location --request GET 'https://localhost:5001/calendars/query'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
#       SELECT `c`.`Id`, `c`.`IsActive`, `c`.`Owner`, `c`.`Type`
#       FROM `Calendars` AS `c`
