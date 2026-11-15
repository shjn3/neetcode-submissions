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
    public int KthSmallest(TreeNode root, int k) {
       return  findKth(root,k);
    }

    int count =0;
    public int findKth(TreeNode node,int k){
        if(node==null) return -1;
        var leftValue = findKth(node.left,k);
        if(leftValue!=-1) return leftValue;
        if(count==k-1) return node.val;
        count++;
        return findKth(node.right,k);
    }

  
}
