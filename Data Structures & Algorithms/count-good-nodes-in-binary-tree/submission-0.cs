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
    public int GoodNodes(TreeNode root) {
        return reversal(root,-101);
    }

    public int reversal(TreeNode root, int max){
        if(root==null) return 0;
        int nextMax = Math.Max(max,root.val);
        int l = reversal(root.left,nextMax);
        int r = reversal(root.right,nextMax);

        if(root.val>=max) return 1+l+r;
        return l+r;
    }
}
