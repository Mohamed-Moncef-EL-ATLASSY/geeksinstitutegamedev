using System;
using System.Collections.Generic;
using System.Linq;

public class Comment
{
  public User Author { get; set; }
  public string Content { get; set; }
  public List<User> Likes { get; set; }
  public DateTime CreatedAt { get; set; }

  public Comment(User author, string content)
  {
    Author = author;
    Content = content;
    Likes = new List<User>();
    CreatedAt = DateTime.Now;
  }

  public void AddLike(User user)
  {
    if (Likes.Contains(user))
    {
      Console.WriteLine($"{user.Name} already liked this comment.");
      return;
    }
    Likes.Add(user);
    Console.WriteLine($"{user.Name} liked the comment.");
  }

  public void RemoveLike(User user)
  {
    if (Likes.Remove(user))
      Console.WriteLine($"{user.Name} unliked the comment.");
  }
}

public class Post
{
  public User Author { get; set; }
  public string Content { get; set; }
  public List<Comment> Comments { get; set; }
  public List<User> Likes { get; set; }
  public DateTime CreatedAt { get; set; }

  public Post(User author, string content)
  {
    Author = author;
    Content = content;
    Comments = new List<Comment>();
    Likes = new List<User>();
    CreatedAt = DateTime.Now;
  }

  public void AddComment(Comment comment)
  {
    if (string.IsNullOrWhiteSpace(comment.Content))
    {
      Console.WriteLine("Comment cannot be empty!");
      return;
    }
    Comments.Add(comment);
    Console.WriteLine($"{comment.Author.Name} commented on {Author.Name}'s post.");
  }

  public void AddLike(User user)
  {
    if (Likes.Contains(user))
    {
      Console.WriteLine($"{user.Name} already liked this post.");
      return;
    }
    Likes.Add(user);
    Console.WriteLine($"{user.Name} liked the post.");
  }

  public void RemoveLike(User user)
  {
    if (Likes.Remove(user))
      Console.WriteLine($"{user.Name} unliked the post.");
  }

  public void Display()
  {
    Console.WriteLine($"\n--- {Author.Name}'s Post ---");
    Console.WriteLine($"Content: {Content}");
    Console.WriteLine($"Posted: {CreatedAt:g}");
    Console.WriteLine($"Likes: {Likes.Count}");

    if (Comments.Count > 0)
    {
      Console.WriteLine($"Comments ({Comments.Count}):");
      foreach (var comment in Comments)
      {
        Console.WriteLine($"  {comment.Author.Name}: {comment.Content} (Likes: {comment.Likes.Count})");
      }
    }
    else
    {
      Console.WriteLine("No comments yet.");
    }
  }
}

public class User
{
  public string Name { get; set; }
  public int Age { get; set; }
  public List<User> Friends { get; set; }
  public List<Post> Posts { get; set; }

  public User(string name, int age)
  {
    Name = name;
    Age = age;
    Friends = new List<User>();
    Posts = new List<Post>();
  }

  public void AddFriend(User user)
  {
    if (user == this)
    {
      Console.WriteLine("You cannot add yourself as a friend!");
      return;
    }

    if (Friends.Contains(user))
    {
      Console.WriteLine($"{user.Name} is already your friend.");
      return;
    }

    Friends.Add(user);
    Console.WriteLine($"{user.Name} added as friend.");
  }

  public void RemoveFriend(User user)
  {
    if (Friends.Remove(user))
      Console.WriteLine($"{user.Name} removed from friends.");
    else
      Console.WriteLine($"{user.Name} is not in your friend list.");
  }

  public void CreatePost(string content)
  {
    if (string.IsNullOrWhiteSpace(content))
    {
      Console.WriteLine("Post content cannot be empty!");
      return;
    }

    Post post = new Post(this, content);
    Posts.Add(post);
    Console.WriteLine($"Post created by {Name}.");
  }

  public void ShowFeed()
  {
    Console.WriteLine($"\n========== {Name}'s Feed ==========");

    if (Friends.Count == 0)
    {
      Console.WriteLine("You have no friends yet!");
      return;
    }

    List<Post> feedPosts = new List<Post>();
    foreach (var friend in Friends)
    {
      feedPosts.AddRange(friend.Posts);
    }

    if (feedPosts.Count == 0)
    {
      Console.WriteLine("No posts in your feed yet.");
      return;
    }

    feedPosts = feedPosts.OrderByDescending(p => p.CreatedAt).ToList();

    foreach (var post in feedPosts)
    {
      post.Display();
    }
  }

  public List<User> GetMutualFriends(User otherUser)
  {
    return Friends.Intersect(otherUser.Friends).ToList();
  }

  public List<User> GetFriendRecommendations()
  {
    List<User> recommendations = new List<User>();
    foreach (var friend in Friends)
    {
      foreach (var friendOfFriend in friend.Friends)
      {
        if (friendOfFriend != this && !Friends.Contains(friendOfFriend) && !recommendations.Contains(friendOfFriend))
        {
          recommendations.Add(friendOfFriend);
        }
      }
    }
    return recommendations;
  }

  public void ShowFriends()
  {
    Console.WriteLine($"\n{Name}'s Friends ({Friends.Count}):");
    if (Friends.Count == 0)
    {
      Console.WriteLine("No friends yet.");
      return;
    }

    foreach (var friend in Friends)
    {
      Console.WriteLine($"  - {friend.Name} ({friend.Age} years old)");
    }
  }

  public void ShowProfile()
  {
    Console.WriteLine($"\n========== {Name}'s Profile ==========");
    Console.WriteLine($"Age: {Age}");
    Console.WriteLine($"Friends: {Friends.Count}");
    Console.WriteLine($"Posts: {Posts.Count}");
    ShowFriends();
  }
}

class Program
{
  static void Main()
  {
    Console.WriteLine("=== Mini Social Network ===\n");

    User moncef = new User("Moncef", 25);
    User mohamed = new User("Mohamed", 30);
    User ciggy = new User("Ciggy", 22);
    User amine = new User("Amine", 28);

    Console.WriteLine("--- Creating Friendships ---");
    moncef.AddFriend(mohamed);
    moncef.AddFriend(ciggy);
    mohamed.AddFriend(ciggy);
    mohamed.AddFriend(amine);
    ciggy.AddFriend(amine);

    Console.WriteLine("\n--- Creating Posts ---");
    moncef.CreatePost("Hello world! Excited to be here.");
    mohamed.CreatePost("Just finished a great project!");
    ciggy.CreatePost("Beautiful day today.");
    amine.CreatePost("Learning C# and loving it!");

    Console.WriteLine("\n--- Adding Comments ---");
    Comment comment1 = new Comment(mohamed, "That's awesome Moncef!");
    moncef.Posts[0].AddComment(comment1);

    Comment comment2 = new Comment(ciggy, "Congratulations Mohamed!");
    mohamed.Posts[0].AddComment(comment2);

    Comment comment3 = new Comment(moncef, "Wish I was there!");
    ciggy.Posts[0].AddComment(comment3);

    Console.WriteLine("\n--- Liking Posts ---");
    mohamed.Posts[0].AddLike(moncef);
    mohamed.Posts[0].AddLike(ciggy);
    ciggy.Posts[0].AddLike(mohamed);
    amine.Posts[0].AddLike(mohamed);

    Console.WriteLine("\n--- Liking Comments ---");
    comment1.AddLike(carol);
    comment2.AddLike(alice);

    Console.WriteLine("\n--- Displaying Profiles ---");
    moncef.ShowProfile();
    mohamed.ShowProfile();

    Console.WriteLine("\n--- Showing Feeds ---");
    moncef.ShowFeed();
    mohamed.ShowFeed();

    Console.WriteLine("\n--- Mutual Friends ---");
    List<User> mutualFriends = moncef.GetMutualFriends(mohamed);
    Console.WriteLine($"\nMutual friends between Moncef and Mohamed: {string.Join(", ", mutualFriends.Select(u => u.Name))}");

    Console.WriteLine("\n--- Friend Recommendations ---");
    List<User> recommendations = moncef.GetFriendRecommendations();
    Console.WriteLine($"\nFriend recommendations for Moncef: {(recommendations.Count > 0 ? string.Join(", ", recommendations.Select(u => u.Name)) : "None")}");

    recommendations = mohamed.GetFriendRecommendations();
    Console.WriteLine($"Friend recommendations for Mohamed: {(recommendations.Count > 0 ? string.Join(", ", recommendations.Select(u => u.Name)) : "None")}");

    Console.WriteLine("\n--- Top Posts (by likes) ---");
    DisplayTopPosts(new List<User> { moncef, mohamed, ciggy, amine }, 3);

    Console.WriteLine("\nThank you for using Mini Social Network!");
  }

  static void DisplayTopPosts(List<User> users, int topCount)
  {
    List<Post> allPosts = new List<Post>();
    foreach (var user in users)
    {
      allPosts.AddRange(user.Posts);
    }

    var topPosts = allPosts.OrderByDescending(p => p.Likes.Count).Take(topCount).ToList();

    Console.WriteLine($"\nTop {topCount} Most Liked Posts:");
    for (int i = 0; i < topPosts.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {topPosts[i].Author.Name}: \"{topPosts[i].Content}\" ({topPosts[i].Likes.Count} likes)");
    }
  }
}
