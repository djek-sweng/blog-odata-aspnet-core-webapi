#!/bin/sh

curl --location --request GET 'https://localhost:5001/meetings/query?$select=Title,Description,Duration&$filter=Duration%20ge%2042'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (1ms) [Parameters=[@__TypedProperty_0='?' (DbType = Int64)], CommandType='Text', CommandTimeout='30']
#       SELECT `m`.`Title`, `m`.`Description`, `m`.`Duration`, `m`.`Id`
#       FROM `Meetings` AS `m`
#       WHERE CAST(`m`.`Duration` AS signed) >= @__TypedProperty_0
