using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlooditData.Models;
using BlooditData.Repositories;
using BlooditWebAPI.GraphQL.Comments;
using BlooditWebAPI.GraphQL.Posts;
using BlooditWebAPI.GraphQL.Topics;
using HotChocolate;

namespace BlooditWebAPI.GraphQL
{
    [GraphQLDescription("Represents type mutations.")]
    public class Mutation
    {
        [GraphQLDescription("Represents the mutation for adding a new topic.")]
        public async Task<TopicAddPayload> AddTopic(
            TopicAddInput input, 
            [Service] IAppRepository repository, 
            [Service] IMapper mapper)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Topic newTopic = mapper.Map<Topic>(input);

            repository.CreateTopic(newTopic);
            await repository.SaveChangesAsync();

            return new TopicAddPayload(newTopic);
        }

        [GraphQLDescription("Represents the mutation for adding a new post.")]
        public async Task<PostAddPayload> AddPost(
            PostAddInput input,
            [Service] IAppRepository repository,
            [Service] IMapper mapper)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Post newPost = mapper.Map<Post>(input);

            repository.CreatePost(newPost);
            await repository.SaveChangesAsync();

            return new PostAddPayload(newPost);
        }

        [GraphQLDescription("Represents the mutation for deleting a post.")]
        public async Task<PostDeletePayload> DeletePost(PostDeleteInput input, [Service] IAppRepository repository)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Post deletedPost = repository.DeletePost(input.Id);
            await repository.SaveChangesAsync();

            return new PostDeletePayload(deletedPost);
        }

        [GraphQLDescription("Represents the mutation for adding a comment.")]
        public async Task<CommentAddPayload> AddComment(
            CommentAddInput input,
            [Service] IAppRepository repository,
            [Service] IMapper mapper)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Comment mappedComment = mapper.Map<Comment>(input);

            Comment addedComment = repository.CreateComment(mappedComment);
            await repository.SaveChangesAsync();

            return new CommentAddPayload(addedComment);
        }

        [GraphQLDescription("Represents the mutation for deleting a comment.")]
        public async Task<CommentDeletePayload> DeleteComment(
            CommentDeleteInput input, 
            [Service] IAppRepository repository, 
            [Service] IMapper mapper)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Comment deletedComment = repository.DeleteComment(input.Id);
            await repository.SaveChangesAsync();

            return new CommentDeletePayload(deletedComment);
        }
    }
}
