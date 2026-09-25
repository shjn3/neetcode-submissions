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
        PriorityQueue<int,int> pq = new();
        if(twitterPostMap.ContainsKey(userId)){
            for(int i =0;i<twitterPostMap[userId].Count;i++){
                (int id,int priority) twitterId =twitterPostMap[userId][i];
                pq.Enqueue(twitterId.id ,-twitterId.priority );
            }
        }
        followerMap.TryGetValue(userId, out var followers);

        if(followers!=null){
            foreach(var follower in followers){
                if(twitterPostMap.ContainsKey(follower)){
                    for(int i =0;i<twitterPostMap[follower].Count;i++){
                        (int id,int priority) twitterId =twitterPostMap[follower][i];
                        pq.Enqueue(twitterId.id ,-twitterId.priority );
                    }
                }   
             }
        }

        List<int> res = new();
        if(pq!=null){

            for(int  i=0;i<10 && pq.Count>0;i++){
                res.Add(pq.Dequeue());
            }
        }
        // Console.WriteLine("Find the result: "+res.Count);
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
