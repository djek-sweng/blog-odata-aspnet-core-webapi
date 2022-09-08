#!/bin/sh

curl --location --request GET 'https://localhost:5001/calendars/query?$select=Owner,Type&$top=2'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (8ms) [Parameters=[@__TypedProperty_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
#       SELECT `c`.`Owner`, `c`.`Type`, `c`.`Id`
#       FROM `Calendars` AS `c`
#       ORDER BY `c`.`Id`
#       LIMIT @__TypedProperty_0
