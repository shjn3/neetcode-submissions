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
    public TreeNode InvertTree(TreeNode root) {
        if(root==null) return null;
        TreeNode newRoot = new TreeNode();
        Copy(root,newRoot);
    
        return newRoot;
    }

    private void Copy(TreeNode root1, TreeNode root2){
        root2.val = root1.val;
        if(root1.left!=null){
            root2.right = new TreeNode();
            Copy(root1.left,root2.right);
        }

        if(root1.right!=null){
            root2.left = new TreeNode();
            Copy(root1.right,root2.left);
        }
    }
}
