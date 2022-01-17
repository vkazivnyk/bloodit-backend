using BlooditData.DbContexts;
using BlooditData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlooditData.Repositories
{
    public sealed class AppRepository : IAppRepository
    {
        private readonly AppDbContext _context;

        public AppRepository(AppDbContext context)
        {
            _context = context;
        }

        public Comment CreateComment(Comment comment) => _context.Add(comment).Entity;

        public Post CreatePost(Post post) => _context.Add(post).Entity;

        public Topic CreateTopic(Topic topic) => _context.Add(topic).Entity;

        public ApplicationUser CreateUser(ApplicationUser user) => _context.Add(user).Entity;

        public Comment DeleteComment(string commentId) => _context.Remove(GetCommentById(commentId)).Entity;

        public Post DeletePost(string postId) => _context.Remove(GetPostById(postId)).Entity;

        public Topic DeleteTopic(string topicId) => _context.Remove(GetTopicById(topicId)).Entity;

        public ApplicationUser DeleteUser(string userId) => _context.Remove(GetUserById(userId)).Entity;

        public Comment GetCommentById(string commentId) => _context.Comments.Find(commentId);

        public IEnumerable<Comment> GetComments() => _context.Comments.ToList();

        public IEnumerable<Comment> GetCommentsByPostId(string postId) =>
            _context.Comments
                .Where(c => c.Post.Id == postId)
                .ToList();

        public IEnumerable<Comment> GetCommentsByUserId(string userId) =>
            _context.Comments
                .Where(c => c.User.Id == userId)
                .ToList();

        public Post GetPostById(string postId) => _context.Posts.Find(postId);

        public IEnumerable<Post> GetPosts() => _context.Posts.ToList();

        public IEnumerable<Post> GetPostsByTopicId(string topicId) =>
            _context.Posts
                .Where(p => p.Topic.Id == topicId)
                .ToList();

        public IEnumerable<Post> GetPostsByUserId(string userId) =>
            _context.Posts
                .Where(p => p.User.Id == userId)
                .ToList();

        public Topic GetTopicById(string topicId) => _context.Topics.Find(topicId);

        public IEnumerable<Topic> GetTopics() => _context.Topics.ToList();

        public Topic GetTopicByPostId(string postId) =>
            _context.Posts
                .FirstOrDefault(p => p.Id == postId)?.Topic;

        public IEnumerable<Topic> GetTopicsByUserId(string userId) =>
            _context.UserTopics
                .Where(ut => ut.UserId == userId)
                .Select(ut => ut.Topic)
                .ToList();

        public ApplicationUser GetUserById(string userId) => _context.Users.Find(userId);

        public IEnumerable<ApplicationUser> GetUsers() => _context.Users.ToList();

        public ApplicationUser GetUserByPostId(string postId) =>
            _context.Posts
                .FirstOrDefault(p => p.Id == postId)?.User;

        public IEnumerable<ApplicationUser> GetUsersByTopicId(string topicId) =>
            _context.UserTopics
                .Where(ut => ut.TopicId == topicId)
                .Select(ut => ut.User)
                .ToList();

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

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
