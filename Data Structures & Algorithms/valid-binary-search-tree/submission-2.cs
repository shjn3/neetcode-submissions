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
    public bool IsValidBST(TreeNode root) {
       return checkBST(root,-1000000001,1000000001);
    }

    public bool checkBST(TreeNode root, int minVal, int maxVal){
        if(root==null) return true;
        // if(!lessThan(root.left,root) || !greaterThan(root.right,root)) return false;
        if( root.val<=minVal || root.val>=maxVal) return false;

        return checkBST(root.left,minVal, root.val)&&checkBST(root.right,root.val,maxVal);
    }




    public bool lessThan(TreeNode a, TreeNode b){
        if(a==null || b==null) return true;
        return a.val<b.val;
    }

    public bool greaterThan(TreeNode a, TreeNode b){
        if(a==null || b==null) return true;
        return a.val>b.val;
    }
}
