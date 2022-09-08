#!/bin/sh

curl --location --request GET 'https://localhost:5001/calendars/query?$select=Owner,Type&$filter=Type%20eq%20%27work%27'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (1ms) [Parameters=[@__TypedProperty_0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
#       SELECT `c`.`Owner`, `c`.`Type`, `c`.`Id`
#       FROM `Calendars` AS `c`
#       WHERE `c`.`Type` = @__TypedProperty_0
