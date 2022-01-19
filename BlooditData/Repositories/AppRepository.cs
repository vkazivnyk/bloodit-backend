using BlooditData.DbContexts;
using BlooditData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlooditData.Repositories
{
    public sealed class AppRepository : IAppRepository
    {
        private readonly AppDbContext _context;

        public AppRepository(AppDbContext context)
        {
            _context = context;
        }

        public Comment CreateComment(Comment comment)
        {
            EntityEntry<Comment> entity = _context.Add(comment);

            entity.Reference(c => c.User).Load();
            entity.Reference(c => c.Post).Load();

            return entity.Entity;
        }

        public Post CreatePost(Post post)
        {
            EntityEntry<Post> entity = _context.Add(post);

            entity.Collection(p => p.Comments).Load();
            entity.Reference(p => p.User).Load();
            entity.Reference(p => p.Topic).Load();

            return entity.Entity;
        }

        public Topic CreateTopic(Topic topic)
        {
            EntityEntry<Topic> entity = _context.Add(topic);

            entity.Collection(t => t.Posts).Load();
            entity.Collection(t => t.UserTopics).Load();

            return entity.Entity;
        }

        public ApplicationUser CreateUser(ApplicationUser user)
        {
            EntityEntry<ApplicationUser> entity = _context.Add(user);

            entity.Collection(u => u.Posts).Load();
            entity.Collection(u => u.Comments).Load();
            entity.Collection(u => u.UserTopics).Load();

            return entity.Entity;
        }

        public Comment DeleteComment(string commentId)
        {
            EntityEntry<Comment> entity = _context.Remove(GetCommentById(commentId));

            entity.Reference(c => c.User).Load();
            entity.Reference(c => c.Post).Load();

            return entity.Entity;
        }

        public Post DeletePost(string postId)
        {
            EntityEntry<Post> entity = _context.Remove(GetPostById(postId));

            entity.Collection(p => p.Comments).Load();
            entity.Reference(p => p.User).Load();
            entity.Reference(p => p.Topic).Load();

            return entity.Entity;
        }

        public Topic DeleteTopic(string topicId)
        {
            EntityEntry<Topic> entity = _context.Remove(GetTopicById(topicId));

            entity.Collection(t => t.Posts).Load();
            entity.Collection(t => t.UserTopics).Load();

            return entity.Entity;
        }

        public ApplicationUser DeleteUser(string userId)
        {
            EntityEntry<ApplicationUser> entity = _context.Remove(GetUserById(userId));

            entity.Collection(u => u.Posts).Load();
            entity.Collection(u => u.Comments).Load();
            entity.Collection(u => u.UserTopics).Load();

            return entity.Entity;
        }

        public Comment GetCommentById(string commentId)
        {
            Comment comment = _context.Comments.Find(commentId);
            if (comment is null)
            {
                return default;
            }

            EntityEntry<Comment> entity = _context.Entry(comment);

            entity.Reference(c => c.User).Load();
            entity.Reference(c => c.Post).Load();

            return entity.Entity;
        }

        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments
                .Include(c => c.Post)
                .Include(c => c.User);
        }

        public IEnumerable<Comment> GetCommentsByPostId(string postId)
        {
            return _context.Comments
                .Include(c => c.Post)
                .Include(c => c.User)
                .Where(c => c.Post.Id == postId);
        }

        public IEnumerable<Comment> GetCommentsByUserId(string userId)
        {
            return _context.Comments
                .Include(c => c.Post)
                .Include(c => c.User)
                .Where(c => c.User.Id == userId);
        }

        public Post GetPostById(string postId)
        {
            Post post = _context.Posts.Find(postId);

            if (post is null)
            {
                return default;
            }

            EntityEntry<Post> entity = _context.Entry(post);

            entity.Collection(p => p.Comments).Load();
            entity.Reference(p => p.User).Load();
            entity.Reference(p => p.Topic).Load();

            return entity.Entity;
        }

        public IEnumerable<Post> GetPosts()
        { 
            return _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.Topic);
        }

        public IEnumerable<Post> GetPostsByTopicId(string topicId)
        {
            return _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.Topic)
                .Where(p => p.Topic.Id == topicId);
        }

        public IEnumerable<Post> GetPostsByUserId(string userId)
        {
            return _context.Posts
                .Include(p => p.Comments)
                .Include(p => p.User)
                .Include(p => p.Topic)
                .Where(p => p.User.Id == userId);
        }

        public Topic GetTopicById(string topicId)
        {
            Topic topic = _context.Topics.Find(topicId);

            if (topic is null)
            {
                return default;
            }

            EntityEntry<Topic> entity = _context.Entry(topic);

            entity.Collection(t => t.Posts).Load();
            entity.Collection(t => t.UserTopics).Load();

            return entity.Entity;
        }

        public IEnumerable<Topic> GetTopics()
        {
            return _context.Topics
                .Include(t => t.Posts)
                .Include(t => t.UserTopics);
        }

        public Topic GetTopicByPostId(string postId)
        {
            Topic topic = _context.Posts.FirstOrDefault(p => p.Id == postId)?.Topic;

            if (topic is null)
            {
                return default;
            }

            EntityEntry<Topic> entity = _context.Entry(topic);

            entity.Collection(t => t.Posts).Load();
            entity.Collection(t => t.UserTopics).Load();

            return entity.Entity;
        }

        public IEnumerable<Topic> GetTopicsByUserId(string userId)
        {
            return _context.UserTopics
                .Where(ut => ut.UserId == userId)
                .Include(ut => ut.Topic)
                .Select(ut => ut.Topic)
                .Include(t => t.Posts)
                .Include(t => t.UserTopics);
        }

        public ApplicationUser GetUserById(string userId)
        {
            ApplicationUser user = _context.Users.Find(userId);

            if (user is null)
            {
                return default;
            }

            EntityEntry<ApplicationUser> entity = _context.Entry(user);
            
            entity.Collection(u => u.Posts).Load();
            entity.Collection(u => u.Comments).Load();
            entity.Collection(u => u.UserTopics).Load();

            return entity.Entity;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
           return _context.Users
                .Include(u => u.Posts)
                .Include(u => u.Comments)
                .Include(u => u.UserTopics);
        }

        public ApplicationUser GetUserByPostId(string postId)
        {
            ApplicationUser user = _context.Posts.FirstOrDefault(p => p.Id == postId)?.User;

            if (user is null)
            {
                return default;
            }

            EntityEntry<ApplicationUser> entity = _context.Entry(user);

            entity.Collection(u => u.Posts).Load();
            entity.Collection(u => u.Comments).Load();
            entity.Collection(u => u.UserTopics).Load();

            return entity.Entity;
        }

        public IEnumerable<ApplicationUser> GetUsersByTopicId(string topicId)
        {
            return _context.UserTopics
                .Where(ut => ut.TopicId == topicId)
                .Include(ut => ut.User)
                .Select(ut => ut.User)
                .Include(u => u.Posts)
                .Include(u => u.Comments)
                .Include(u => u.UserTopics);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public Comment UpdateComment(Comment comment)
        {
            EntityEntry<Comment> entity = _context.Update(comment);

            entity.Reference(c => c.User).Load();
            entity.Reference(c => c.Post).Load();

            return entity.Entity;
        }

        public Post UpdatePost(Post post)
        {
            EntityEntry<Post> entity = _context.Update(post);

            entity.Collection(p => p.Comments).Load();
            entity.Reference(p => p.User).Load();
            entity.Reference(p => p.Topic).Load();

            return entity.Entity;
        }

        public Topic UpdateTopic(Topic topic)
        {
            EntityEntry<Topic> entity = _context.Update(topic);

            entity.Collection(t => t.Posts).Load();
            entity.Collection(t => t.UserTopics).Load();

            return entity.Entity;
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            EntityEntry<ApplicationUser> entity =_context.Update(user);

            entity.Collection(u => u.Posts).Load();
            entity.Collection(u => u.Comments).Load();
            entity.Collection(u => u.UserTopics).Load();

            return entity.Entity;
        }

        public ApplicationUser GetUserByCommentId(string commentId)
        {
            ApplicationUser user =_context.Comments.FirstOrDefault(c => c.Id == commentId)?.User;

            if (user is null)
            {
                return default;
            }

            EntityEntry<ApplicationUser> entity = _context.Entry(user);

            entity.Collection(u => u.Posts).Load();
            entity.Collection(u => u.Comments).Load();
            entity.Collection(u => u.UserTopics).Load();

            return entity.Entity;
        }

        public Post GetPostByCommentId(string commentId)
        {
            Post post =_context.Comments.FirstOrDefault(c => c.Id == commentId)?.Post;

            if (post is null)
            {
                return default;
            }

            EntityEntry<Post> entity = _context.Entry(post);

            entity.Collection(p => p.Comments).Load();
            entity.Reference(p => p.User).Load();
            entity.Reference(p => p.Topic).Load();

            return entity.Entity;
        }
    }
}
