using BlooditData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlooditData.Repositories
{
    public class MockAppRepository : IAppRepository
    {
        private readonly List<ApplicationUser> _users;
        private readonly List<Topic> _topics;
        private readonly List<Post> _posts;
        private readonly List<Comment> _comments;

        public MockAppRepository()
        {
            _users = new List<ApplicationUser>()
            {
                new()
                {
                    Id="flkjsdfjksd",
                    UserTopics = new List<UserTopic>()
                    {
                        new()
                        {
                            Id = 1,
                            UserId = "flkjsdfjksd",
                            TopicId = "fjkdshfljsd",
                            User = new()
                            {
                                Id = "flkjsdfjksd",
                            },
                            Topic = new()
                            {
                                Id = "fjkdshfljsd",
                            }
                        }
                    },
                    Posts = new List<Post>()
                    {
                        new()
                        {
                            Id = "dasdaqsdwdsklfd",
                            AuthorId = "flkjsdfjksd",
                            TopicId = "fjkdshfljsd",
                            Heading = "dead inside",
                            Body = "how to detect dead inside 3-S rank ghoul in dota 2",
                            Date = DateTime.Now,
                            Likes = 1337,
                            Dislikes = 0
                        }
                    },
                    Comments = new List<Comment>()
                    {
                        new()
                        {
                            Id = "asdljasdsad",
                            AuthorId = "flkjsdfjksd",
                            PostId = "dasdaqsdwdsklfd",
                            Date = DateTime.Now.AddSeconds(15),
                            Text = "the best dead inside ever",
                            Likes = 100,
                            Dislikes = 0
                        }
                    }
                }
            };

            _topics = new List<Topic>()
            {
                new()
                {
                    Id = "fjkdshfljsd",
                    Name = "dota 2 science",
                    CreationDate = DateTime.Now,
                    Posts = new List<Post>()
                    {
                        new()
                        {
                            Id = "dasdaqsdwdsklfd",
                            AuthorId = "flkjsdfjksd",
                            TopicId = "fjkdshfljsd",
                            Heading = "dead inside",
                            Body = "how to detect dead inside 3-S rank ghoul in dota 2",
                            Date = DateTime.Now,
                            Likes = 1337,
                            Dislikes = 0
                        }
                    },
                    UserTopics = new List<UserTopic>()
                    {
                        new()
                        {
                            Id = 1,
                            UserId = "flkjsdfjksd",
                            TopicId = "fjkdshfljsd",
                            User = new()
                            {
                                Id = "flkjsdfjksd",
                            },
                            Topic = new()
                            {
                                Id = "fjkdshfljsd",
                            }
                        }
                    }
                }
            };

            _posts = new List<Post>()
            {
                new()
                {
                    Id = "dasdaqsdwdsklfd",
                    AuthorId = "flkjsdfjksd",
                    TopicId = "fjkdshfljsd",
                    Heading = "dead inside",
                    Body = "how to detect dead inside 3-S rank ghoul in dota 2",
                    Date = DateTime.Now,
                    Likes = 1337,
                    Dislikes = 0,
                    User = _users[0],
                    Topic = _topics[0]
                }
            };

            _comments = new List<Comment>()
            {
                new()
                {
                    Id = "asdljasdsad",
                    AuthorId = "flkjsdfjksd",
                    PostId = "dasdaqsdwdsklfd",
                    Date = DateTime.Now.AddSeconds(15),
                    Text = "the best dead inside ever",
                    Likes = 100,
                    Dislikes = 0,
                    User = _users[0],
                    Post = _posts[0]
                }
            };
        }

        public Comment CreateComment(Comment comment) 
        {
            throw new NotImplementedException();
        }

        public Post CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Topic CreateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser CreateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Comment DeleteComment(string commentId)
        {
            throw new NotImplementedException();
        }

        public Post DeletePost(string postId)
        {
            throw new NotImplementedException();
        }

        public Topic DeleteTopic(string topicId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Comment GetCommentById(string commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments(string commentId)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(string postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPosts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPosts(string postId)
        {
            throw new NotImplementedException();
        }

        public Topic GetTopicById(string topicId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetTopics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetTopics(string userId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserById(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetUsers(string topicId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Comment UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Post UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Topic UpdateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
