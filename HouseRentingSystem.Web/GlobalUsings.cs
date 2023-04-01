global using System.Diagnostics;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;

global using AutoMapper;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Migrations;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

global using HouseRentingSystem.Services.Data;
global using HouseRentingSystem.Services.Interfaces;
global using HouseRentingSystem.Services.Enums;
global using HouseRentingSystem.Services.Models;
global using HouseRentingSystem.Services;
global using HouseRentingSystem.Services.Models.Home;
global using HouseRentingSystem.Services.Models.Agent;
global using HouseRentingSystem.Services.Models.House;
global using HouseRentingSystem.Services.Models.Statistics;
global using HouseRentingSystem.Services.Data.Entities;
global using HouseRenting.System.Data.Configuration;
global using static HouseRentingSystem.AdminConstants;
global using HouseRentingSystem.Services.Data.Entities.Configuration;
global using static HouseRentingSystem.Constants.MessageConstants;
global using static HouseRentingSystem.Services.Data.Entities.DataConstants.AgentConstants;
global using static HouseRentingSystem.Services.Data.Entities.DataConstants.ApplicationUserConstants;
global using static HouseRentingSystem.Services.Data.Entities.DataConstants.CategoryConstants;
global using static HouseRentingSystem.Services.Data.Entities.DataConstants.HouseConstants;
