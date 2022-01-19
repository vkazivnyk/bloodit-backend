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
        private readonly List<UserTopic> _userTopics;
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
                            User = new ApplicationUser()
                            {
                                Id = "flkjsdfjksd",
                            },
                            Topic = new Topic()
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
                            User = new ApplicationUser()
                            {
                                Id = "flkjsdfjksd",
                            },
                            Topic = new Topic()
                            {
                                Id = "fjkdshfljsd",
                            }
                        }
                    }
                }
            };

            _userTopics = new List<UserTopic>()
            {
                new()
                {
                    Id = 1,
                    UserId = "flkjsdfjksd",
                    TopicId = "fjkdshfljsd",
                    User = _users[0],
                    Topic = _topics[0]
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
                throw new ArgumentNullException(nameof(comment));
            }

            _comments.Add(comment);

            return comment;
        }

        public Post CreatePost(Post post)
        {
            if (post is null)
            {
                throw new ArgumentNullException(nameof(post));
            }

            _posts.Add(post);

            return post;
        }

        public Topic CreateTopic(Topic topic)
        {
            if (topic is null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            _topics.Add(topic);

            return topic;
        }

        public ApplicationUser CreateUser(ApplicationUser user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _users.Add(user);

            return user;
        }

        public Comment DeleteComment(string commentId)
        {
            if (string.IsNullOrEmpty(commentId))
            {
                throw new ArgumentException();
            }

            Comment comment = _comments.Find(c => c.Id == commentId);
            _comments.Remove(comment);

            return comment;
        }

        public Post DeletePost(string postId)
        {
            if (string.IsNullOrEmpty(postId))
            {
                throw new ArgumentException();
            }

            Post post = _posts.Find(p => p.Id == postId);
            _posts.Remove(post);

            return post;
        }

        public Topic DeleteTopic(string topicId)
        {
            if (string.IsNullOrEmpty(topicId))
            {
                throw new ArgumentException();
            }

            Topic topic = _topics.Find(t => t.Id == topicId);
            _topics.Remove(topic);

            return topic;
        }

        public ApplicationUser DeleteUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException();
            }

            ApplicationUser user = _users.Find(u => u.Id == userId);
            _users.Remove(user);

            return user;
        }

        public Comment GetCommentById(string commentId) => _comments.Find(c => c.Id == commentId);

        public IEnumerable<Comment> GetComments() => _comments;

        public IEnumerable<Comment> GetCommentsByPostId(string postId) => _comments.Where(c => c.Post.Id == postId);

        public IEnumerable<Comment> GetCommentsByUserId(string userId) => _comments.Where(c => c.User.Id == userId);

        public Post GetPostById(string postId) => _posts.Find(p => p.Id == postId);

        public IEnumerable<Post> GetPosts() => _posts;
        public Post GetPostByCommentId(string commentId) => _comments.FirstOrDefault(c => c.Id == commentId)?.Post;

        public IEnumerable<Post> GetPostsByTopicId(string topicId) => _posts.Where(p => p.Topic.Id == topicId);

        public IEnumerable<Post> GetPostsByUserId(string userId) => _posts.Where(p => p.User.Id == userId);

        public Topic GetTopicById(string topicId) => _topics.Find(t => t.Id == topicId);

        public IEnumerable<Topic> GetTopics() => _topics;
        public Topic GetTopicByPostId(string postId) => _posts.FirstOrDefault(p => p.Id == postId)?.Topic;

        public IEnumerable<Topic> GetTopicsByUserId(string userId) =>
            _userTopics
            .Where(ut => ut.UserId == userId)
            .Select(ut => ut.Topic)
            .ToList();

        public ApplicationUser GetUserById(string userId) => _users.Find(u => u.Id == userId);

        public IEnumerable<ApplicationUser> GetUsers() => _users;
        public ApplicationUser GetUserByPostId(string postId) => _posts.FirstOrDefault(p => p.Id == postId)?.User;

        public ApplicationUser GetUserByCommentId(string commentId) =>
            _comments.FirstOrDefault(c => c.Id == commentId)?.User;

        public IEnumerable<ApplicationUser> GetUsersByTopicId(string topicId) =>
            _userTopics
                .Where(ut => ut.TopicId == topicId)
                .Select(ut => ut.User)
                .ToList();

        public Task<int> SaveChangesAsync() => Task.Run(() => 1);

        public Comment UpdateComment(Comment comment)
        {
            Comment oldComment = _comments.Find(c => c.Id == comment.Id);
            int id = _comments.IndexOf(oldComment);
            if (id < 0 || id > _comments.Count)
            {
                throw new KeyNotFoundException();
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
                throw new KeyNotFoundException();
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
                throw new KeyNotFoundException();
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
                throw new KeyNotFoundException();
            }

            _users[id] = user;
            return user;
        }
    }
}
