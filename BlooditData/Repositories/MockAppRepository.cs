using BlooditData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlooditData.Repositories
{
    public sealed class MockAppRepository : IAppRepository
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
            if (comment is null)
            {
                throw new NullReferenceException();
            }

            _comments.Add(comment);

            return comment;
        }

        public Post CreatePost(Post post)
        {
            if (post is null)
            {
                throw new NullReferenceException();
            }

            _posts.Add(post);

            return post;
        }

        public Topic CreateTopic(Topic topic)
        {
            if (topic is null)
            {
                throw new NullReferenceException();
            }

            _topics.Add(topic);

            return topic;
        }

        public ApplicationUser CreateUser(ApplicationUser user)
        {
            if (user is null)
            {
                throw new NullReferenceException();
            }

            _users.Add(user);

            return user;
        }

        public Comment DeleteComment(string commentId)
        {
            if (string.IsNullOrEmpty(commentId))
            {
                throw new NullReferenceException();
            }

            Comment comment = _comments.Find(c => c.Id == commentId);
            _comments.Remove(comment);

            return comment;
        }

        public Post DeletePost(string postId)
        {
            if (string.IsNullOrEmpty(postId))
            {
                throw new NullReferenceException();
            }

            Post post = _posts.Find(p => p.Id == postId);
            _posts.Remove(post);

            return post;
        }

        public Topic DeleteTopic(string topicId)
        {
            if (string.IsNullOrEmpty(topicId))
            {
                throw new NullReferenceException();
            }

            Topic topic = _topics.Find(t => t.Id == topicId);
            _topics.Remove(topic);

            return topic;
        }

        public ApplicationUser DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new NullReferenceException();
            }

            ApplicationUser user = _users.Find(u => u.Id == userId);
            _users.Remove(user);

            return user;
        }

        public Comment GetCommentById(string commentId) => _comments.Find(c => c.Id == commentId);

        public IEnumerable<Comment> GetComments() => _comments;

        public IEnumerable<Comment> GetComments(string postId) => _comments.Where(c => c.Post.Id == postId);

        public Post GetPostById(string postId) => _posts.Find(p => p.Id == postId);

        public IEnumerable<Post> GetPosts() => _posts;

        public IEnumerable<Post> GetPosts(string userId) => _posts.Where(p => p.User.Id == userId);

        public Topic GetTopicById(string topicId) => _topics.Find(t => t.Id == topicId);

        public IEnumerable<Topic> GetTopics() => _topics;

        public IEnumerable<Topic> GetTopics(string userId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserById(string userId) => _users.Find(u => u.Id == userId);

        public IEnumerable<ApplicationUser> GetUsers() => _users;

        public IEnumerable<ApplicationUser> GetUsers(string topicId)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync() => Task.CompletedTask;

        public Comment UpdateComment(Comment comment)
        {
            Comment oldComment = _comments.Find(c => c.Id == comment.Id);
            int id = _comments.IndexOf(oldComment);
            if (id < 0 || id > _comments.Count)
            {
                throw new IndexOutOfRangeException();
            }

            _comments[id] = comment;
            return comment;
        }

        public Post UpdatePost(Post post)
        {
            Post oldPost = _posts.Find(p => p.Id == post.Id);
            int id = _posts.IndexOf(oldPost);
            if (id < 0 || id > _posts.Count)
            {
                throw new IndexOutOfRangeException();
            }

            _posts[id] = post;
            return post;
        }

        public Topic UpdateTopic(Topic topic)
        {
            Topic oldTopic = _topics.Find(t => t.Id == topic.Id);
            int id = _topics.IndexOf(oldTopic);
            if (id < 0 || id > _topics.Count)
            {
                throw new IndexOutOfRangeException();
            }

            _topics[id] = topic;
            return topic;
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            ApplicationUser oldUser = _users.Find(u => u.Id == user.Id);
            int id = _users.IndexOf(oldUser);
            if (id < 0 || id > _users.Count)
            {
                throw new IndexOutOfRangeException();
            }

            _users[id] = user;
            return user;
        }
    }
}
