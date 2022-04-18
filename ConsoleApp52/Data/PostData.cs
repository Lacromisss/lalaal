using ConsoleApp52.Models;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp52.Data
{
    internal class PostData
    {
        public int AddPost(Post post)
        {
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"insert into Post (Title,Content) values(@title,@content)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("title", post.Title);
                cmd.Parameters.AddWithValue("Content", post.Content);



                return cmd.ExecuteNonQuery();


            }
            static void EditPostTitle(string title, string id)
            {
                using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
                {
                    con.Open();
                    string query = $"update Post set Title=@title where Id=@id)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("title", title);
                    cmd.ExecuteNonQuery();



                }



            }







        }
        //DEQIQ
        public Post GetPostById(string id)
        {
            Post postss = new Post();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Stadions WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("id", id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {




                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            postss.Id = dr.GetInt32(0);
                            postss.Title = dr.GetString(1);
                            postss.Content = dr.GetString(2);

                        }
                    }
                    else return null;

                }
            }
            return postss;
        }
        //DEQIQ
        static List<Post> GetAllPosts()
        {
            List<Post> post = new List<Post>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {

                con.Open();

                string query = "SELECT * FROM Post";

                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Post post1 = new Post
                        {
                            Id = dr.GetInt32(0),
                            Title = dr.GetString(1),
                            Content = dr.GetString(2),
                            
                        };

                        post.Add(post1);
                    }
                }
                return post;



            }

        }
        //deyesen deqiq
        public int DeletePost(string id)
        {
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();

                string query = "delete * from Post where Id=@id";
                SqlCommand cmd= new SqlCommand(query, con);
              

             var result = cmd.ExecuteNonQuery();
                return result;


            }






        }

    }


}


        
    

