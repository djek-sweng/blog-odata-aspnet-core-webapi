#!/bin/sh

curl --location --request GET 'https://localhost:5001/calendars/query?$filter=indexof(Owner,%20%27Arthur%27)%20gt%20-1'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (2ms) [Parameters=[@__TypedProperty_0='?' (Size = 4000), @__TypedProperty_1='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
#       SELECT `c`.`Id`, `c`.`IsActive`, `c`.`Owner`, `c`.`Type`
#       FROM `Calendars` AS `c`
#       WHERE (LOCATE(@__TypedProperty_0, `c`.`Owner`) - 1) > @__TypedProperty_1
