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
    public List<int> RightSideView(TreeNode root) {
        List<int> res = new();
        if(root==null) return res;
        Queue<TreeNode> q =new();
        q.Enqueue(root);
        while(q.Count>0){
            int size = q.Count;
            for(int i=0;i<size-1;i++){
                var n = q.Dequeue();
                if(n.left!=null)  q.Enqueue(n.left);
                if(n.right!=null) q.Enqueue(n.right);
            }
            if(size>0){
                var n = q.Dequeue();
                if(n.left!=null)  q.Enqueue(n.left);
                if(n.right!=null) q.Enqueue(n.right);
                res.Add(n.val);
            }
        }
        return res;
    }
}
