using BlooditData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlooditData.Repositories
{
    public interface IAppRepository
    {
        Task<int> SaveChangesAsync();
        ApplicationUser CreateUser(ApplicationUser user);
        Topic CreateTopic(Topic topic);
        Post CreatePost(Post post);
        Comment CreateComment(Comment comment);
        ApplicationUser UpdateUser(ApplicationUser user);
        Topic UpdateTopic(Topic topic);
        Post UpdatePost(Post post);
        Comment UpdateComment(Comment comment);
        ApplicationUser DeleteUser(string userId);
        Topic DeleteTopic(string topicId);
        Post DeletePost(string postId);
        Comment DeleteComment(string commentId);
        ApplicationUser GetUserById(string userId);
        Topic GetTopicById(string topicId);
        Post GetPostById(string postId);
        Comment GetCommentById(string commentId);
        IEnumerable<ApplicationUser> GetUsers();
        IEnumerable<ApplicationUser> GetUsersByTopicId(string topicId);
        IEnumerable<Topic> GetTopics();
        IEnumerable<Topic> GetTopicsByUserId(string userId);
        IEnumerable<Post> GetPosts();
        IEnumerable<Comment> GetComments();
    }
}
