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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root==null) return null;
        if(root.val<=p.val && root.val>=q.val || root.val>=p.val && root.val<=q.val) return root;

        if(root.val>p.val && root.val>q.val){
            return LowestCommonAncestor(root.left,p,q);
        }
        if(root.val<p.val && root.val<q.val) return LowestCommonAncestor(root.right,p,q);
        return root;
    }
}
