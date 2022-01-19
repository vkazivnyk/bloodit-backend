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
            Comment toCreate = _context.Comments.CreateProxy();
            _context.Entry(toCreate).CurrentValues.SetValues(comment);
            return _context.Add(comment).Entity;
        }

        public Post CreatePost(Post post)
        {
            Post toCreate = _context.Posts.CreateProxy();
            _context.Entry(toCreate).CurrentValues.SetValues(post);
            return _context.Add(post).Entity;
        }

        public Topic CreateTopic(Topic topic)
        {
            Topic toCreate = _context.Topics.CreateProxy();
            _context.Entry(toCreate).CurrentValues.SetValues(topic);
            return _context.Add(topic).Entity;
        }

        public ApplicationUser CreateUser(ApplicationUser user)
        {
            ApplicationUser toCreate = _context.Users.CreateProxy();
            _context.Entry(toCreate).CurrentValues.SetValues(user);
            return _context.Add(user).Entity;
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

        public Comment GetCommentById(string commentId) => _context.Comments.Find(commentId);

        public IEnumerable<Comment> GetComments() => _context.Comments;

        public IEnumerable<Comment> GetCommentsByPostId(string postId) =>
            _context.Comments
                .Where(c => c.Post.Id == postId);

        public IEnumerable<Comment> GetCommentsByUserId(string userId) =>
            _context.Comments
                .Where(c => c.User.Id == userId);

        public Post GetPostById(string postId) => _context.Posts.Find(postId);

        public IEnumerable<Post> GetPosts() => _context.Posts.ToList();

        public IEnumerable<Post> GetPostsByTopicId(string topicId) =>
            _context.Posts
                .Where(p => p.Topic.Id == topicId);

        public IEnumerable<Post> GetPostsByUserId(string userId) =>
            _context.Posts
                .Where(p => p.User.Id == userId);

        public Topic GetTopicById(string topicId) => _context.Topics.Find(topicId);

        public IEnumerable<Topic> GetTopics() => _context.Topics;

        public Topic GetTopicByPostId(string postId) =>
            _context.Posts
                .FirstOrDefault(p => p.Id == postId)?.Topic;

        public IEnumerable<Topic> GetTopicsByUserId(string userId) =>
            _context.UserTopics
                .Where(ut => ut.UserId == userId)
                .Select(ut => ut.Topic);

        public ApplicationUser GetUserById(string userId) => _context.Users.Find(userId);

        public IEnumerable<ApplicationUser> GetUsers() => _context.Users;

        public ApplicationUser GetUserByPostId(string postId) =>
            _context.Posts
                .FirstOrDefault(p => p.Id == postId)?.User;

        public IEnumerable<ApplicationUser> GetUsersByTopicId(string topicId) =>
            _context.UserTopics
                .Where(ut => ut.TopicId == topicId)
                .Select(ut => ut.User);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public Comment UpdateComment(Comment comment) => _context.Update(comment).Entity;

        public Post UpdatePost(Post post) => _context.Update(post).Entity;

        public Topic UpdateTopic(Topic topic) => _context.Update(topic).Entity;

        public ApplicationUser UpdateUser(ApplicationUser user) => _context.Update(user).Entity;

        public ApplicationUser GetUserByCommentId(string commentId) =>
            _context.Comments
                .FirstOrDefault(c => c.Id == commentId)?.User;

        public Post GetPostByCommentId(string commentId) =>
            _context.Comments
                .FirstOrDefault(c => c.Id == commentId)?.Post;
    }
}
