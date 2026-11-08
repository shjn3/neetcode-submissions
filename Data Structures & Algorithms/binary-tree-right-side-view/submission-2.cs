/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    List<int> ans = new();
    public List<int> RightSideView(TreeNode root) {
        DFS(root,0);
        return ans;
    }

    public void DFS(TreeNode node, int level){
        if(node ==null) return;
        if(ans.Count==level) {
            ans.Add(node.val);
        }
        DFS(node.right,level+1);
        DFS(node.left,level+1);
    }
}
