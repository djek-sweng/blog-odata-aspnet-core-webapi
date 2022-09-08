#!/bin/sh

curl --location --request GET 'https://localhost:5001/calendars/query?$filter=Type%20eq%20%27work%27&$expand=Meetings'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (3ms) [Parameters=[@__TypedProperty_0='?' (Size = 4000)], CommandType='Text', CommandTimeout='30']
#       SELECT `c`.`Id`, `c`.`IsActive`, `c`.`Owner`, `c`.`Type`, `m`.`Id`, `m`.`CalendarId`, `m`.`Description`, `m`.`Duration`, `m`.`StartAt`, `m`.`Title`
#       FROM `Calendars` AS `c`
#       LEFT JOIN `Meetings` AS `m` ON `c`.`Id` = `m`.`CalendarId`
#       WHERE `c`.`Type` = @__TypedProperty_0
#       ORDER BY `c`.`Id`
