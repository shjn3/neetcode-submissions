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
    public int DiameterOfBinaryTree(TreeNode root) {
        int res =0;
        DFS(root,ref res);
        return res;
    }

    public int DFS(TreeNode root, ref int res){
        if(root==null) return 0;
        int leftHeight = DFS(root.left, ref res);
        int rightHeight = DFS(root.right,ref res);
        res = Math.Max(res, leftHeight+rightHeight);

        return 1 +Math.Max(leftHeight,rightHeight);
    }
}
