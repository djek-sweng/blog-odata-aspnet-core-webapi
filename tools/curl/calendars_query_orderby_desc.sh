#!/bin/sh

curl --location --request GET 'https://localhost:5001/calendars/query?$select=Owner,Type&$orderby=Owner%20desc'

# info: Microsoft.EntityFrameworkCore.Database.Command[20101]
#       Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
#       SELECT `c`.`Owner`, `c`.`Type`, `c`.`Id`
#       FROM `Calendars` AS `c`
#       ORDER BY `c`.`Owner` DESC
