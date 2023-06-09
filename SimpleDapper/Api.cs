using DataAccess.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SimpleDapper
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/GetAllUsers", GetUsers);
            app.MapGet("/GetUserById/{id}", GetUser);
            app.MapPost("/InsertUsers", InsertUser);
            app.MapPut("/UpdateUser", UpdateUser);
            app.MapDelete("/DeleteUser/{id}", DeleteUser);

            app.MapGet("/GetDownloadCountByUser/{id}", GetNumberOfDownloads);
            app.MapGet("/GetBooksDownloadedByUser/{id}", GetBooksDownloaded);
            app.MapPost("/InsertNewBook",InsertNewBook);
            app.MapPost("/InsertDownloadData", InsertDownloadData);
        }

        private static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUser(int id, IUserData data)
        {
            try
            {
                var results = await data.GetUser(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertUser(UserModel model, IUserData data)
        {
            try
            {
                await data.InsertUser(model);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }

        private static async Task<IResult> UpdateUser(UserModel model, IUserData data)
        {
            try
            {
                await data.UpdateUser(model);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }

        private static async Task<IResult> DeleteUser(int id,IUserData data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetNumberOfDownloads(int? id,IDownloadData downloadData)
        {
            try
            {
                var count = await downloadData.GetDownloadsByUser(id);
                //if (count == null) return Results.NotFound();
                return Results.Ok(count);    
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBooksDownloaded(int id, IBookData bookData)
        {
            try
            {
                var results = await bookData.GetBooksDownloadedByUser(id);
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertNewBook(IBookData bookData, BookModel model)
        {
            try
            {
                await bookData.InsertNewBook(model);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertDownloadData(IDownloadData data, DownloadsModel model)
        {
            try
            {
                var result = await data.InsertDownloadData(model);
                if (result == -1) return Results.Text("UserID or BookID not present");
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }
    }
}
