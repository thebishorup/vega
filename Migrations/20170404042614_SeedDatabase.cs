﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make3')");

            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make1-ModleA', (SELECT ID FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make1-ModleB', (SELECT ID FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make1-ModleC', (SELECT ID FROM Makes WHERE Name = 'Make1'))");

            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make2-ModleA', (SELECT ID FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make2-ModleB', (SELECT ID FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make2-ModleC', (SELECT ID FROM Makes WHERE Name = 'Make2'))");

            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make3-ModleA', (SELECT ID FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make3-ModleB', (SELECT ID FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Modles (Name, MakeId) VALUES ('Make3-ModleC', (SELECT ID FROM Makes WHERE Name = 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //We do do not need to have Modle because Makes would have cascade delete
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Make1', 'Make2', 'Make3')");
        }
    }
}
