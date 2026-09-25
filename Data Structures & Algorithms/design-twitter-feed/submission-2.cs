public class Twitter {

    Dictionary<int,HashSet<int>> followerMap = new();
    Dictionary<int,List<(int,int)>> twitterPostMap = new();
    int id =0;

    public Twitter() {
        
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(!twitterPostMap.ContainsKey(userId)){
            twitterPostMap.Add(userId,new());
        }

        twitterPostMap[userId].Add((tweetId,id++));
    }
    
    public List<int> GetNewsFeed(int userId) {
        List<int> people = new();
        people.Add(userId);
        if(followerMap.ContainsKey(userId)){
            foreach(var follower in followerMap[userId]){
                people.Add(follower);
            }
        }

        PriorityQueue<int,int> pq = new();

        foreach(var person in people){
            if(twitterPostMap.ContainsKey(person)){
                var posts = twitterPostMap[person];
                foreach(var post in posts){
                    pq.Enqueue( post.Item1,- post.Item2);
                }
            }
        }
        List<int> res = new();
        for(int i =0;i<10&&pq.Count>0;i++){
            res.Add(pq.Dequeue());
        }

        return res;
    }
    
    public void Follow(int followerId, int followeeId) {
        if(!followerMap.ContainsKey(followerId)){
            followerMap.Add(followerId,new());
        }

        followerMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
         if(!followerMap.ContainsKey(followerId)){
             return;
        }

           followerMap[followerId].Remove(followeeId);
    }
}
