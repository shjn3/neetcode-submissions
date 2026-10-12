public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int,List<int>> prerequisiteMap = new();
        for(int i =0;i<prerequisites.Length;i++){
            if(!prerequisiteMap.ContainsKey(prerequisites[i][0])){
                prerequisiteMap.Add(prerequisites[i][0],new());
            }
            prerequisiteMap[prerequisites[i][0]].Add(prerequisites[i][1]);
            if(prerequisites[i][0]==prerequisites[i][1]) return false;
        }
        int  c=0;
        bool[] cources = new bool[numCourses];
        for(int j=0;j<numCourses;j++){
            for(int i =0;i<numCourses;i++){
                if(cources[i]) continue;
                if(!prerequisiteMap.ContainsKey(i)){
                    cources[i] = true;
                    c++;
                    continue;
                }
                bool taken = true;
                foreach(var adj in prerequisiteMap[i]){
                    if(!cources[adj]){
                        taken = false;
                        break;
                    }
                }
                if(taken){
                    c++;
                }
                cources[i] = taken;
            }
        }

        return c == numCourses;
    }
}
