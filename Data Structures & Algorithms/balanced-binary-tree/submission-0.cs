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
    public bool IsBalanced(TreeNode root) {
        if(root==null) return true;
        int heightLeft = GetHeight(root.left);
        int heightRight = GetHeight(root.right);
        bool isBalanceLeft = IsBalanced(root.left);
        bool isBalanceRight = IsBalanced(root.right);
        if(!isBalanceLeft || !isBalanceRight) return false;
        if(Math.Abs(heightLeft-heightRight)<=1) return true;
        return false;
    }

    public int GetHeight(TreeNode root){
        if(root==null) return 0;
        int leftHeight = GetHeight(root.left);
        int rightHeight = GetHeight(root.right);

        return Math.Max(leftHeight,rightHeight)+1;
    }
}
