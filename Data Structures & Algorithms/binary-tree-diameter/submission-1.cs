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
        if(root==null||root.left==null && root.right == null) return 0;
        int ans = 0;
        if(root.left!=null){
            ans +=1 + GetHeight(root.left);
        }

        if(root.right!=null){
            ans+=1+GetHeight(root.right);
        }

        int dia1 = DiameterOfBinaryTree(root.left);
        int dia2 = DiameterOfBinaryTree(root.right);
   
        return Math.Max(dia1,Math.Max(dia2,ans));
    }

    public int GetHeight(TreeNode root){
        if(root==null) return 0;
        int res = -1;

        if(root.left!=null){
            res = GetHeight(root.left);
        }

        if(root.right!=null){
            res = Math.Max(GetHeight(root.right),res);
        }

        return res==-1?0:res+1;
    }
}
