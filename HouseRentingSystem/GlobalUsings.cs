global using System.Diagnostics;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using HouseRentingSystem.Data;
global using HouseRentingSystem.Enums;
global using HouseRentingSystem.Models;
global using HouseRentingSystem.Services;
global using HouseRentingSystem.Interfaces;
global using HouseRentingSystem.Models.Home;
global using HouseRentingSystem.Models.Agent;
global using HouseRentingSystem.Models.House;
global using HouseRentingSystem.Data.Entities;
global using HouseRentingSystem.Models.Statistics;
global using HouseRentingSystem.Data.Configuration;
global using static HouseRentingSystem.AdminConstants;
global using HouseRentingSystem.Data.Entities.Configuration;
global using static HouseRentingSystem.Constants.MessageConstants;
global using static HouseRentingSystem.Data.Entities.DataConstants.AgentConstants;
global using static HouseRentingSystem.Data.Entities.DataConstants.ApplicationUserConstants;
global using static HouseRentingSystem.Data.Entities.DataConstants.CategoryConstants;
global using static HouseRentingSystem.Data.Entities.DataConstants.HouseConstants;
