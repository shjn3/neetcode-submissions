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
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> res = new();
        if(root==null) return res;

        Queue<TreeNode> q = new();

        q.Enqueue(root);
        while(q.Count>0){
            List<int> l = new();
            int size = q.Count;
            for(int i =0;i<size;i++){
                TreeNode n = q.Dequeue();
                l.Add(n.val);
                if(n.left!=null){
                    q.Enqueue(n.left);
                }
                if(n.right!=null){
                    q.Enqueue(n.right);
                }
            }
            res.Add(l);
        }

        return res;
    }



}
