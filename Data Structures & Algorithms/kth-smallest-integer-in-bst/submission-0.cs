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
       findKth(root,k);
       return res;
    }

    int res =-1;
    int count =0;
    public bool findKth(TreeNode node,int k){
        if(res!=-1) return true;
        if(node==null) return false;
        if(node.left==null &&node.right==null){
            if(count==k-1){
                res= node.val;
                return true;
            }
            count++;
            return false;
        }
        if(node.left!=null){
            if(findKth(node.left,k)){
                return true;
            }
        }
        if(count==k-1){
            res = node.val;
            return true;
        }
        count++;
        return findKth(node.right,k);
    }

  
}
